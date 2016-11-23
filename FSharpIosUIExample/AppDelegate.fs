namespace FSharpIosUIExample

open System

open UIKit
open Foundation

module ViewControllers =

    let mutable private homeVC = Lazy<HomeVC>.Create(fun() -> new HomeVC())
    let getHomeVC() = homeVC.Value

    let mutable private settingsVC = Lazy<SettingsVC>.Create(fun() -> new SettingsVC())
    let getSettingsVC() = settingsVC.Value

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    member this.goHome(e:EventArgs) =
        this.Window.RootViewController <- ViewControllers.getHomeVC()

    member this.goToSettings(e:EventArgs) =
        this.Window.RootViewController <- ViewControllers.getSettingsVC()

    override val Window = null with get, set

    override this.FinishedLaunching (app, options) =
        this.Window <- new UIWindow(UIScreen.MainScreen.Bounds)
        this.Window.RootViewController <- ViewControllers.getHomeVC()
        this.Window.MakeKeyAndVisible()
        ViewControllers.getHomeVC().Button.PrimaryActionTriggered
            |> Observable.subscribe(this.goToSettings)
            |> ignore
        ViewControllers.getSettingsVC().Button.PrimaryActionTriggered
            |> Observable.subscribe(this.goHome)
            |> ignore
        true
