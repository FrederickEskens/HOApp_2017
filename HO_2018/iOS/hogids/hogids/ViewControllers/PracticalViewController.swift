//
//  PracticalViewController.swift
//  HO gids
//
//  Created by Jeroen Crevits on 05/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit

class PracticalViewController: UIViewController {

    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var lblSubtitleInfo: UILabel!
    @IBOutlet weak var lblDetailInfoPoint: UILabel!
    @IBOutlet weak var lblSubtitleBar: UILabel!
    @IBOutlet weak var lblDetailBar: UILabel!
    @IBOutlet weak var lblSubtitleWIFI: UILabel!
    @IBOutlet weak var lblDetailWIFI: UILabel!
    @IBOutlet weak var lblSubtitleFirstAid: UILabel!
    @IBOutlet weak var lblDetailFirstAid: UILabel!
    @IBOutlet weak var lblCallEmergency: UILabel!
    @IBOutlet weak var btnCallEmergency: UIButton!
    @IBOutlet weak var lblShowFirstAid: UILabel!
    @IBOutlet weak var btnShowFirstAid: UIButton!
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
