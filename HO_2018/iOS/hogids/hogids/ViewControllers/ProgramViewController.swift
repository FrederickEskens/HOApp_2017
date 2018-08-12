//
//  ProgramViewController.swift
//  HO gids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit
import ViewPager_Swift

class ProgramViewController: UIViewController {

    @IBOutlet weak var lblTopTitle: UILabel!
    @IBOutlet weak var vwPageHolder: UIView!
    
    var viewPager : ViewPagerController?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        lblTopTitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.TABBAR_ITEM2)
        
        // Do any additional setup after loading the view.
    }
    
    override func viewDidLayoutSubviews() {
        setupViewPager()
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

extension ProgramViewController: ViewPagerControllerDelegate, ViewPagerControllerDataSource{
    func numberOfPages() -> Int {
        return 3
    }
    
    func viewControllerAtPosition(position: Int) -> UIViewController {
        let dayViewController = (UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "DayProgramTableViewController") as! DayProgramTableViewController)
        dayViewController.day = position
        return dayViewController
    }
    
    func tabsForPages() -> [ViewPagerTab] {
        let tab1 = ViewPagerTab(title: "Vrijdag", image: nil)
        let tab2 = ViewPagerTab(title: "Zaterdag", image: nil)
        let tab3 = ViewPagerTab(title: "Zondag", image: nil)
        return [tab1,tab2,tab3]
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
