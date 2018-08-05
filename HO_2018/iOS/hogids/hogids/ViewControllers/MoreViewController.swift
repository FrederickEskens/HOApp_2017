//
//  MoreViewController.swift
//  HO gids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit
import ViewPager_Swift

class MoreViewController: UIViewController {

    @IBOutlet weak var lblTopTitle: UILabel!
    @IBOutlet weak var vwPageHolder: UIView!
    
    var viewPager : ViewPagerController?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        lblTopTitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.TABBAR_ITEM5)
        setupViewPager()
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override var preferredStatusBarStyle: UIStatusBarStyle {
        get {
            return .lightContent
        }
    }

}

extension MoreViewController: ViewPagerControllerDelegate, ViewPagerControllerDataSource{
    func numberOfPages() -> Int {
        return 2
    }
    
    func viewControllerAtPosition(position: Int) -> UIViewController {
        if position == 0 {
            let dayViewController = (UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "InfoViewController") as! PracticalViewController)
            return dayViewController
        }else {
            let dayViewController = (UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "RulesViewController") as! RulesViewController)
            return dayViewController
        }
        
    }
    
    func tabsForPages() -> [ViewPagerTab] {
        let tab1 = ViewPagerTab(title: "Info", image: nil)
        let tab2 = ViewPagerTab(title: "Leefregels", image: nil)
        return [tab1,tab2]
    }
    
    func setupViewPager() {
        let myOptions = ViewPagerOptions(viewPagerWithFrame: vwPageHolder.bounds)
        myOptions.fitAllTabsInView = true
        myOptions.tabIndicatorViewBackgroundColor = Colors.TabBarSelectedBackground
        myOptions.tabViewBackgroundDefaultColor = UIColor.white
        myOptions.tabViewTextHighlightColor = Colors.TabBarSelectedBackground
        myOptions.tabViewTextDefaultColor = Colors.TabBarSelectedBackground
        myOptions.tabViewTextFont = Fonts.Roboto16
        myOptions.isTabHighlightAvailable = true
        myOptions.tabViewBackgroundHighlightColor = UIColor.white
        myOptions.tabViewHeight = 64
        myOptions.tabIndicatorViewHeight = 3
        
        viewPager = ViewPagerController()
        viewPager!.options = myOptions
        viewPager!.dataSource = self
        viewPager!.delegate = self
        
        //Now let me add this to my viewcontroller
        self.addChildViewController(viewPager!)
        vwPageHolder.addSubview(viewPager!.view)
        viewPager!.didMove(toParentViewController: self)
    }
    
}
