//
//  BoomTabBarController.swift
//  Boom
//
//  Created by Jeroen Crevits on 09/07/2018.
//  Copyright © 2018 Bazookas. All rights reserved.
//

import UIKit
import FirebaseAnalytics

class HOTabBarController: UITabBarController {

    var itemLabels = [Copy.TABBAR_ITEM1,Copy.TABBAR_ITEM2,Copy.TABBAR_ITEM3,Copy.TABBAR_ITEM4,Copy.TABBAR_ITEM5]
    var itemIcons = [
        (Icons.Home, 25),
        (Icons.Program, 25),
        (Icons.Map, 25),
        (Icons.Theme, 25),
        (Icons.More, 25)]
    
    var hasShownLocationAuthorization = false
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.tabBar.tintColor = Colors.TabBarSelected
        self.tabBar.unselectedItemTintColor = Colors.hoBlack
        self.tabBar.backgroundImage = UIImage.imageWithColor(color: UIColor.white, size: self.tabBar.frame.size)
        self.tabBar.shadowImage = UIImage()
        selectedIndex = 0
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)
        let tabItems = self.tabBar.items!
        
        for index in 0..<tabItems.count {
            let currentItem = tabItems[index] as UITabBarItem
            //currentItem.titlePositionAdjustment = UIOffset.init(horizontal: 0, vertical: -10)
            currentItem.title = LocalStorage.Instance.getCopy(copyKey: itemLabels[index])?.uppercased()
            //currentItem.setTitleTextAttributes([NSAttributedStringKey.font:Fonts.!], for: .normal)
            let image = Utils.createIconFontImage(letter: itemIcons[index].0, size: itemIcons[index].1)
            currentItem.image = image
            currentItem.selectedImage = image
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override func viewWillLayoutSubviews() {
        var tabFrame = self.tabBar.frame
        tabFrame.size.width = self.view.frame.width + 4
        tabFrame.origin.x = -2
        self.tabBar.frame = tabFrame;
        
        // Set selected item background color
        let numberOfItems = CGFloat(tabBar.items!.count)
        let tabBarItemSize = CGSize(width: tabBar.frame.width / numberOfItems, height: tabFrame.height)
        tabBar.selectionIndicatorImage = UIImage.imageWithColor(color: Colors.TabBarSelectedBackground, size: tabBarItemSize).resizableImage(withCapInsets: UIEdgeInsets.zero)
    }

}
