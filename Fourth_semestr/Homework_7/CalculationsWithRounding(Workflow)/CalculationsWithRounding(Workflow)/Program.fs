module Program

type MaybeBuid () =
    member this.Bind(x, f) =
        match x with
        | None -> None
        | Some a -> f a
    member this.Return(x) = Some x

let maybe = new MaybeBuid()

//    rounding 3 {
//        let! a = 2.0 / 12.0
//        let! b = 3.5
//        return a / b
//    }

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
