//
//  RulesViewController.swift
//  HO gids
//
//  Created by Jeroen Crevits on 05/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit

class RulesViewController: UIViewController {

    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var lblIntro: UILabel!
    @IBOutlet weak var imgRule1: UIImageView!
    @IBOutlet weak var imgRule2: UIImageView!
    @IBOutlet weak var imgRule3: UIImageView!
    @IBOutlet weak var imgRule4: UIImageView!
    @IBOutlet weak var imgRule5: UIImageView!
    @IBOutlet weak var imgRule6: UIImageView!
    @IBOutlet weak var imgRule7: UIImageView!
    @IBOutlet weak var lblRulesFooter: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()
        lblTitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.Rules_Title)
        lblIntro.text = LocalStorage.Instance.getCopy(copyKey: Copy.Rules_IntroText)
        lblRulesFooter.text = LocalStorage.Instance.getCopy(copyKey: Copy.Rules_FooterText)
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

}
