   M S B A M L   `   `   `  ????V  RContinuousGestureBasics-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Microsoft.Samples.Kinect.ContinuousGestureBasics0Microsoft.Samples.Kinect.ContinuousGestureBasics  5   	   A    ;Microsoft.Samples.Kinect.ContinuousGestureBasics.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Plocal>clr-namespace:Microsoft.Samples.Kinect.ContinuousGestureBasics     5   	   -   5          ? Title$  Continuous Gesture Basics??5   	   $	??680??5   	   $	??790??6    ? 	Resources 5
         MediumGreyBrush ?? Color  KinectPurpleBrush  KinectBlueBrush??%?   &	        &	 #     &	 F     ?? 5   
   $ 	#ff6e6e6e??62   ?? 5   
   $ 	#ff52318f??64   ?? 5   
   $ 	#ff00BCF2??62   5      .??5      ? $??	10 0 10 0q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??0??6   $??Images\Logo.png??6   $
??Left=?66   $
??Fill=?6Q   $??32??6`   $??81??6l   $??0 10 0 5q?6w   ?? 5   
   $??0??6   $??Right=?6!   $??Continuous Gesture Basics??6=   $??Bottom=?6^   $??0 0 -1 0q?6y   #??[  6?   $??Segoe UI)?6?   $??18(?6?   ?? 5   
   $??0??6   $??Images\Status.png??6   $
??None=?68   $??Center=?6G   $??0 0 0 5q?6d   ? 5   
   -   5         ?Name$ contentGrid??5      $??1??6$   $??Center=?61   $??Center=?6N    ? ColumnDefinitions 5      ?? 5      $??1* ?6#   ?? 5      $??2* ?6#    5       ?? 5!      $
??Auto ?6    ?? 5"      $
??Auto ?6    ?? 5#      $??* ?6    ?? 5$      $
??Auto ?6    .+?5'      ?? $??0??6   $??0??6)   $??5q?66   .+?5(      ?? $??Kinect Viewbox??6   $??20(?62   $??Segoe UI)?6@   #??[ 6V   $??SemiBold"?6?   $??0??6?   $??5q?6?   (? 5)      -   5         (?Name$ kinectBodyViewbox??5)      .??5*      ?? $??UniformToFill=?6;   ??6   ?? *ImageSource+6;   5+      5,      ? 5.      -   5        $ gestureResultGrid??5.      $??0??6.   $??1??6>   $
??Auto??6K   $??5q?6X   $	??Top=?6c   ??5/      ?? 50       ?? 
TargetType" ?6    ?? Triggers 51      ?? 52      	 ?? Binding	 6*   ?? *	IsTracked+
 ?? Value
 True6H   .a?53   "   ??  ?? Property ? ?? ?? Value
 ???d?6?   54      ?? 55      	 6*   ?? *	IsTracked+	
 False6H   .a?56   "   ??  ? ??
 ?????6?   57      59       5;      ?? 5<      $
??Auto ?6$   ?? 5=      $
??Auto ?6$   ?? 5>      $
??Auto ?6$   ?? 5?      $
??Auto ?6$   ?? 5@      $
??Auto ?6$   .+?5B      ?? $??Gesture Results??6   $??20(?63   $??Segoe UI)?6A   $??SemiBold"?6W   #??[ 6m   $??0??6?   $??5q?6?   ?? 5C      $??18(?6U   $??Segoe UI)?6c   $??SemiBold"?6y   $??1??6?   $??5q?6?   ??6   ?? *
TurnLeft+ ?? StringFormat$ Turn Left: {0}??6?   ?? 5D      $??18(?6W   $??Segoe UI)?6e   $??SemiBold"?6{   $??2??6?   $??5q?6?   ??6   ?? *	TurnRight+$ Turn Right: {0}??6?   ?? 5E      $??18(?6]   $??Segoe UI)?6k   $??SemiBold"?6?   $??3??6?   $??5q?6?   ??6   ?? *KeepStraight+$ Keep Straight: {0}??6?   ?? 5F      $??18(?6_   $??Segoe UI)?6m   $??SemiBold"?6?   $??4??6?   $??5q?6?   ??6   ?? *SteerProgress+$ Steer Progress: {0}??6?   5G      ? 5I      -   5        $ collisionResultGrid??5I      $??0??60   $??2??6@   $??5q?6M   
???   ?$	??Top=?6k    5J      ?? 5K      $
??Auto ?6$   ?? 5L      $
??Auto ?6$   .+?5N      ?? $??18(?6\   $??Segoe UI)?6j   
???????$??0??6?   $??5q?6?   ??6   ?? *CollisionCount+$ Collisions: {0}??6?   ?? 5O      $??18(?6p   $??Segoe UI)?6~   
???????$??1??6?   $??5q?6?   ??6   ?? *TimeSinceCollision+$# Last Collision: {0:mm\:ss\.f}??6?   5P      ?? 5R      $??2??6   $??3??6,   $????Instructions: When your body appears in the Kinect Viewbox, you can control the ship. Pretend to hold a fake steering wheel in your hands. Turn the wheel left or right to rotate the ship. Open your hands to stop the ship.??69   $
??Wrap=?6  $??10q?62  #??[  6>  $??Segoe UI)?6l  $??14(?6?  ? 5T      -   5        $ 	spaceGrid??5T      $??1??6&   $??3??66   $??5q?6G   }?. .+?5U      ?? -   5         ??Name$ 
spaceImage??5U      $??Images\space.png??6,   $??UniformToFill=?6F   }?. 6^   5V      5X      ?? 5Z   
   -   5        $??	statusBar??5Z   ?   $??2??6   $??Stretch=?6!   $??Bottom=?6P   
???????#??[ 6~   .@?5[      ?? ??6   ?? *
StatusText+5\      5]      5^      