type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

type ContinuationStep<'a> =
    | Finished
    | Step of 'a * (unit -> ContinuationStep<'a>)

let rec linearize binTree cont =
    match binTree with
    | Tip x -> cont()
    | Tree(x, l, r) -> Step (x, (fun () -> linearize l (fun () -> linearize r cont)))

let iter f binTree =
    let steps = linearize binTree (fun () -> Finished)
    let rec processSteps step =
        match step with
        | Finished -> ()
        | Step(x, getNext) -> f x
                              processSteps (getNext())
    processSteps steps



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
