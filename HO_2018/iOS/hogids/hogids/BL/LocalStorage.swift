//
//  LocalData.swift
//  HO
//
//  Created by Jeroen Crevits on 09/07/2018.
//  Copyright © 2018 Bazookas. All rights reserved.
//

import Foundation
import SQLite

class LocalStorage {
    
    private static var _instance : LocalStorage?
    static var Instance : LocalStorage {
        get {
            if _instance == nil {
                _instance = LocalStorage()
            }
            return _instance!
        }
    }
    
    private var db : Connection!
    
    private var translations:[String:String] = [:]
    
    func setupDB(){
        // Move database file from bundle to documents folder
        
        let fileManager = FileManager.default
        
        let documentsUrl = fileManager.urls(for: .documentDirectory,
                                            in: .userDomainMask)
        
        guard documentsUrl.count != 0 else {
            return // Could not find documents URL
        }
        
        let finalDatabaseURL = documentsUrl.first!.appendingPathComponent("HO.sqlite")
        
        if !( (try? finalDatabaseURL.checkResourceIsReachable()) ?? false) {
            print("DB does not exist in documents folder")
            
            let documentsURL = Bundle.main.resourceURL?.appendingPathComponent("HO.sqlite")
            
            do {
                try fileManager.copyItem(atPath: (documentsURL?.path)!, toPath: finalDatabaseURL.path)
            } catch let error as NSError {
                print("Couldn't copy file to final location! Error:\(error.description)")
            }
            
        } else {
            print("Database file found at path: \(finalDatabaseURL.path)")
        }
        
        
        
        let path = NSSearchPathForDirectoriesInDomains(
            .documentDirectory, .userDomainMask, true
            ).first!
        do {
            db = try Connection("\(path)/HO.sqlite")
            let value = Expression<String?>("copyValue_NL")
            let key = Expression<String?>("copyKey")
            let copyTable = Table("tblCopy")
            for copyItem in try db.prepare(copyTable){
                translations[copyItem[key]!] = copyItem[value]!
            }
        } catch {
            print(error.localizedDescription)
        }
        
    }
    
    func getCopy(copyKey:String) -> String?{
        if let value = translations[copyKey] {
            return value
        }else{
            print("Copy not found: \(copyKey)")
            return copyKey
        }
    }
    
    func getProgram(forDay:Int) -> [ProgramItem]{
        var returnList : [ProgramItem] = []
        do {
            let day = Expression<Int?>("ParentID")
            let title = Expression<String?>("Title")
            let timeBegin = Expression<String?>("TimeBegin")
            let timeEnd = Expression<String?>("TimeEnd")
            let location = Expression<Int?>("LocationID")
            let programTable = Table("tblProgram")
            for programItem in try db.prepare(programTable.select(title, timeBegin, timeEnd, location).where(day == forDay + 1)){
                
                
                let item = ProgramItem.init(Title: programItem[title], Time: "\(programItem[timeBegin] ?? "...") - \(programItem[timeEnd] ?? "...")", Location: getLocation(forID: programItem[location] ?? 0))
                returnList.append(item)
            }
        } catch {
            print(error.localizedDescription)
        }
        return returnList
    }
    
    func getLocation(forID:Int) -> String{
        var returnString = ""
        do {
            let id = Expression<Int?>("ID")
            let name = Expression<String?>("Name")
            let table = Table("tblLocations")
            for locationItem in try db.prepare(table.select(name).where(id == forID)){
                returnString = locationItem[name] ?? ""
                break
            }
        } catch {
            print(error.localizedDescription)
        }
        return returnString
    }
    
}
