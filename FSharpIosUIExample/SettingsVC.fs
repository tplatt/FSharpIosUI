namespace FSharpIosUIExample

open System
open Foundation
open UIKit

open UIHelperFunctions

[<Register ("SettingsVC")>]
type SettingsVC  =
    inherit UIViewController
        new () = { inherit UIViewController("SettingsVC", null) }
        new (name:String, bundle:NSBundle) = { inherit UIViewController(name, bundle) }
        new (handle:IntPtr) = { inherit UIViewController(handle:IntPtr) }

    member x.getElement name =
        UIHelper.getElementInViews(x.View.Subviews, name)

    member x.Button = x.getElement "GoHomeButton" :?> UIButton

    override x.DidReceiveMemoryWarning () =
        base.DidReceiveMemoryWarning ()
      
    override x.ViewDidLoad () =
        base.ViewDidLoad ()
       
    override x.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation) =
        if UIDevice.CurrentDevice.UserInterfaceIdiom = UIUserInterfaceIdiom.Phone then
           toInterfaceOrientation <> UIInterfaceOrientation.PortraitUpsideDown
        else
           true


