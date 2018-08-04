//
//  LocationController.swift
//  Plopsaland
//
//  Created by Jeroen Crevits on 03/04/2018.
//  Copyright © 2018 Bazookas. All rights reserved.
//
import CoreLocation
import Foundation
import UIKit
import MapKit

class LocationController: NSObject, CLLocationManagerDelegate, UIAlertViewDelegate {
    
    var locationManager: CLLocationManager
    static let defaultContoller : LocationController = LocationController()
    var locationChangedListener: LocationUpdatedDelegate?
    var permissionChangedListener: LocationPermissionChangedDelegate?
    var userLocation: CLLocation?
    
    override init() {
        locationManager = CLLocationManager()
        super.init()
        locationManager.delegate = self
        locationManager.desiredAccuracy = kCLLocationAccuracyBest
    }
    
    func startUpdatingLocation(listener : LocationUpdatedDelegate?) {
        self.locationChangedListener = listener
        
        if (CLLocationManager.authorizationStatus() == CLAuthorizationStatus.notDetermined){
            locationManager.requestWhenInUseAuthorization()
        }else {
            if !CLLocationManager.locationServicesEnabled() || CLLocationManager.authorizationStatus() == .denied {
                return
            } else {
                //Location Services Enabled, let's start location updates
                locationManager.startUpdatingLocation()
            }
        }
    }
    
    func stopUpdatingLocation() {
        locationManager.stopUpdatingLocation()
        self.locationChangedListener = nil
    }
    
    func locationManager(_ manager: CLLocationManager, didChangeAuthorization status: CLAuthorizationStatus) {
        if !CLLocationManager.locationServicesEnabled() || CLLocationManager.authorizationStatus() == .denied {
    
        }
        if (status != .notDetermined){
            if permissionChangedListener != nil {
                permissionChangedListener?.permissionChanged(status: status)
            }
        }
    }
    
    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        userLocation = manager.location
        guard locationChangedListener != nil else {
            return
        }
        locationChangedListener!.locationUpdated(coordinates: manager.location?.coordinate)
    }
    
    func lastUserLocation() -> CLLocation? {
        return userLocation
    }
    
    func requestLocation(listener : LocationPermissionChangedDelegate?){
        self.permissionChangedListener = listener
        if (CLLocationManager.authorizationStatus() == CLAuthorizationStatus.notDetermined){
            locationManager.requestWhenInUseAuthorization()
        }else {
            listener?.permissionChanged(status: CLLocationManager.authorizationStatus())
        }
    }
    
    func locationEnabled() -> Bool{
        return (CLLocationManager.authorizationStatus() == CLAuthorizationStatus.authorizedWhenInUse || CLLocationManager.authorizationStatus() == CLAuthorizationStatus.authorizedAlways) && CLLocationManager.locationServicesEnabled() && userLocation != nil
    }
    
    func driveTo(lat: CLLocationDegrees, long: CLLocationDegrees, poiName: String?) {
        let location = CLLocationCoordinate2DMake(lat, long)
        if !openWaze(location: location){
            if !openGoogleMaps(location: location){
                openAppleMaps(location: location, name: poiName)
            }
        }
    }
    
    func openWaze(location : CLLocationCoordinate2D) -> Bool {
        if UIApplication.shared.canOpenURL(URL(string: "waze://")!) {
            let url = URL(string: "waze://?ll=\(location.latitude),\(location.longitude)&navigate=yes")!
            UIApplication.shared.open(url)
            return true
        } else {
            return false
        }
    }
    
    func openGoogleMaps(location : CLLocationCoordinate2D) -> Bool{
        if (UIApplication.shared.canOpenURL(URL(string: "comgooglemaps://")!)) {
            let url = URL(string: "comgooglemaps://?saddr=&daddr=\(location.latitude),\(location.longitude)&directionsmode=driving")!
            UIApplication.shared.open(url)
            return true
        } else {
            return false
        }
    }
    
    func openAppleMaps(location: CLLocationCoordinate2D, name: String?) {
        let regionDistance:CLLocationDistance = 10000
        let coordinates = CLLocationCoordinate2DMake(location.latitude, location.longitude)
        let regionSpan = MKCoordinateRegionMakeWithDistance(coordinates, regionDistance, regionDistance)
        let options = [
            MKLaunchOptionsMapCenterKey: NSValue(mkCoordinate: regionSpan.center),
            MKLaunchOptionsMapSpanKey: NSValue(mkCoordinateSpan: regionSpan.span)
        ]
        let placemark = MKPlacemark(coordinate: coordinates, addressDictionary: nil)
        let mapItem = MKMapItem(placemark: placemark)
        mapItem.name = name
        mapItem.openInMaps(launchOptions: options)
    }
}

protocol LocationUpdatedDelegate: class {
    func locationUpdated(coordinates:CLLocationCoordinate2D?)
}

protocol LocationPermissionChangedDelegate: class {
    func permissionChanged(status : CLAuthorizationStatus)
}


