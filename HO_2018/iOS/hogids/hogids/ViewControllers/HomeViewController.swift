//
//  ViewController.swift
//  hogids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit

class HomeViewController: UIViewController {

    @IBOutlet weak var imgIntroTopImage: UIImageView!
    @IBOutlet weak var lblintroTitle: UILabel!
    @IBOutlet weak var lblIntroSubtitle: UILabel!
    @IBOutlet weak var lblIntroText: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()
        
        lblintroTitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.Intro_Title)
        lblIntroSubtitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.Intro_SubTitle)
        lblIntroText.text = LocalStorage.Instance.getCopy(copyKey: Copy.Intro_IntroText)
        
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

