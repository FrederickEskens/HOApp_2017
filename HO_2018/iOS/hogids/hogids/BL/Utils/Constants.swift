//
//  Utils.swift
//  HO gids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import Foundation
import UIKit

class Copy {
    static let TABBAR_ITEM1 = "TABBAR_ITEM1"
    static let TABBAR_ITEM2 = "TABBAR_ITEM2"
    static let TABBAR_ITEM3 = "TABBAR_ITEM3"
    static let TABBAR_ITEM4 = "TABBAR_ITEM4"
    static let TABBAR_ITEM5 = "TABBAR_ITEM5"
    
    static let Intro_Title = "Intro_Title"
    static let Intro_SubTitle = "Intro_SubTitle"
    static let Intro_IntroText = "Intro_IntroText"
    
    static let Song_Title = "Song_Title"
    static let Song_Subtitle = "Song_Subtitle"
    static let Song_Text = "Song_Text"
}


class Fonts {
    static func imageFont(size: CGFloat) -> UIFont {
        return UIFont(name: "hoFont", size: size)!
    }
    
    static let Roboto16 = UIFont(name: "Roboto-Regular", size: 16)!
}

class Colors {
    static let TabBarSelected = #colorLiteral(red: 1, green: 1, blue: 1, alpha: 1)
    static let hoBlack = #colorLiteral(red: 0.2745098039, green: 0.2745098039, blue: 0.2745098039, alpha: 1)
    static let TabBarSelectedBackground = #colorLiteral(red: 0.3843137255, green: 0.5098039216, blue: 0.1607843137, alpha: 1)
}

class Icons{
    static let Home = "A"
    static let Program = "B"
    static let Map = "C"
    static let Theme = "D"
    static let More = "E"
}

class Constants {
    static var defaultLocale: (String)? = {
        return "nl"
    }()
    
    static let ItunesURL = "itms-apps://itunes.apple.com/app/id672639920"
}
