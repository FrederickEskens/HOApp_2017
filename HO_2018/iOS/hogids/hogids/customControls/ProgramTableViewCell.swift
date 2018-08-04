//
//  ProgramTableViewCell.swift
//  HO gids
//
//  Created by Jeroen Crevits on 04/08/2018.
//  Copyright © 2018 Scouts & Gidsen Vlaanderen. All rights reserved.
//

import UIKit

class ProgramTableViewCell: UITableViewCell {

    @IBOutlet weak var lblTimeFrame: UILabel!
    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var lblSubTitle: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }
    
    func setData(item:ProgramItem) {
        lblTitle.text = item.Title
        lblSubTitle.text = item.Location
        lblTimeFrame.text = item.Time
    }

}

struct ProgramItem {
    var Title : String?
    var Time : String?
    var Location : String?
}
