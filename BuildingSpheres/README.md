# Building Spheres

[Codewars URL](https://www.codewars.com/kata/55c1d030da313ed05100005d)

### Arguments for the constructor
```
radius -> integer
mass -> integer
```
### Methods to be defined
```cs
GetRadius()       =>  radius of the Sphere
GetMass()         =>  mass of the Sphere
GetVolume()       =>  volume of the Sphere (a double rounded to 5 place after the decimal)
GetSurfaceArea()  =>  surface area of the Sphere (a double rounded to 5 place after the decimal)
GetDensity()      =>  density of the Sphere (a double rounded to 5 place after the decimal)
```
### Example
```cs
Sphere ball = new Sphere(2,50)
ball.GetRadius() ->       2
ball.GetMass() ->         50
ball.GetVolume() ->       33.51032
ball.GetSurfaceArea() ->  50.26548
ball.GetDensity() ->      1.49208
```