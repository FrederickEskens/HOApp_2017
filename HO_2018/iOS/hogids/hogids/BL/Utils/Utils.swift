//
//  Utils.swift
//  Boom
//
//  Created by Jeroen Crevits on 09/07/2018.
//  Copyright © 2018 Bazookas. All rights reserved.
//
import Foundation
import UIKit

class Utils {
    
    static func createIconFontImage(letter: String, size: Int) -> UIImage {
        let label = UILabel(frame: CGRect(x: 0, y: 0, width: size, height: size))
        label.text = letter
        label.font = Fonts.imageFont(size: CGFloat(size))
        label.textColor = .white
        
        // Take a snapshot
        UIGraphicsBeginImageContextWithOptions(CGSize(width: size, height: size), false, 0.0)
        label.layer.render(in: UIGraphicsGetCurrentContext()!)
        let snapshot = UIGraphicsGetImageFromCurrentImageContext()
        UIGraphicsEndImageContext()
        
        return snapshot!
    }
    
    static func isIphoneX() -> Bool {
        if UIDevice().userInterfaceIdiom == .phone {
            switch UIScreen.main.nativeBounds.height {
            case 2436:
                return true
            default:
                return false
            }
        }
        return false
    }
}
