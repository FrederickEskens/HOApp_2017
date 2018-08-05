//
//  ThemeViewController.swift
//  HO gids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit

class ThemeViewController: UIViewController {

    @IBOutlet weak var lblThemeTitle: UILabel!
    @IBOutlet weak var lblMusicGroup: UILabel!
    @IBOutlet weak var lblSongText: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()

        lblThemeTitle.text = LocalStorage.Instance.getCopy(copyKey: Copy.Song_Title)
        lblMusicGroup.text = LocalStorage.Instance.getCopy(copyKey: Copy.Song_Subtitle)
        lblSongText.text = LocalStorage.Instance.getCopy(copyKey: Copy.Song_Text)
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
