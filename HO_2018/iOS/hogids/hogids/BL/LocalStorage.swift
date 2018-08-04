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
    
}
