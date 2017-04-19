module testclass

type Vector(x:float, y:float) =
    member v.Scale s = Vector(x * s, y * s)
    member v.X = x
    member val XX = x with get, set
    member val YY = y with get, set 

//let f v =
//    let vector = Vector(1.0, 1.0)
//    vector.X <- 2.0


