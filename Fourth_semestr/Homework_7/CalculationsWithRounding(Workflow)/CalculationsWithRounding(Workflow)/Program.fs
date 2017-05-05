module Program

type RoundBuilder(r:int) =
    member this.Bind(x : float, f) = f <| System.Math.Round (x, r)
    member this.Return(x : float) = System.Math.Round (x, r)
          
type RoundingBuilder() =
    member this.Bind((x:float, r:int), f) = f <| System.Math.Round (x, r)
    member this.Return(x:float, r:int) = System.Math.Round (x, r)

let rounding = new RoundingBuilder()



let compute x y r func =
    rounding {
        let! x' = (x, r)
        let! y' = (y, r)
        return (func x' y', r)
        }

let divide x y =
    match y with
    | 0.0 -> None
    | _ -> Some (x / y)

let round r = new RoundBuilder(r)

let calculate x y func =
    round 3 {
        let! x' = x
        let! y' = y
        return (func x' y')
        }

//    rounding 3 {
//        let! a = 2.0 / 12.0
//        let! b = 3.5
//        return a / b
//    }

[<EntryPoint>]
let main argv = 
    let b = compute (2.0 / 12.0) 3.5 3 (fun x y -> x / y)
    let c = calculate (2.0 / 12.0) 3.5 (fun x y -> x / y)
    //    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
