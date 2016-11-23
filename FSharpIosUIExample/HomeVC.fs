namespace FSharpIosUIExample

open System
open Foundation
open UIKit

open UIHelperFunctions

[<Register ("HomeVC")>]
type HomeVC  =
    inherit UIViewController
        new () = { inherit UIViewController("HomeVC", null) }
        new (name:String, bundle:NSBundle) = { inherit UIViewController(name, bundle) }
        new (handle:IntPtr) = { inherit UIViewController(handle:IntPtr) }

    member x.getElement name =
        UIHelper.getElementInViews(x.View.Subviews, name)

    member x.Button = x.getElement "SettingsButton" :?> UIButton

    override x.DidReceiveMemoryWarning () =
        base.DidReceiveMemoryWarning ()
      
    override x.ViewDidLoad () =
        base.ViewDidLoad ()
       
    override x.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation) =
        if UIDevice.CurrentDevice.UserInterfaceIdiom = UIUserInterfaceIdiom.Phone then
           toInterfaceOrientation <> UIInterfaceOrientation.PortraitUpsideDown
        else
           true

