type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

type ContinuationStep<'a> =
    | Finished
    | Step of 'a * (unit -> ContinuationStep<'a>)

let rec linearize binTree cont =
    match binTree with
    | Tip x -> Step (x, fun () -> cont())
    | Tree(x, l, r) -> Step (x, (fun () -> linearize l (fun () -> linearize r cont)))

let iter f binTree =
    let steps = linearize binTree (fun () -> Finished)
    let rec processSteps step =
        match step with
        | Finished -> ()
        | Step(x, getNext) -> f x
                              processSteps (getNext())
    processSteps steps

let rec map binTree f =
    match binTree with
    | Tip x -> Tip <| f x
    | Tree (x, l, r) -> Tree (f x, map l f, map r f)

let tree1 = 
    Tree(
        "as",
        Tree ("re", Tip "fj", Tip "lk"),
        Tree ("haf", Tip "bo", Tip "po")
        )

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    let tree2 = map tree1 (fun x -> x + x)
    iter (printfn "%A") tree2
    0 // возвращение целочисленного кода выхода
