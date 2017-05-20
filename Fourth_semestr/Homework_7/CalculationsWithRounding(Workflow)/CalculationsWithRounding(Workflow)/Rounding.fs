module Rounding

type RoundingBuilder(r:int) =
    member this.Bind(x : float, f) = f <| System.Math.Round (x, r)
    member this.Return(x : float) = System.Math.Round (x, r)

let divide x y =
    match y with
    | 0.0 -> None
    | _ -> Some (x / y)

let round r = new RoundingBuilder(r)

let calculate x y func =
    round 3 {
        let! x' = x
        let! y' = y
        return (func x' y')
        }