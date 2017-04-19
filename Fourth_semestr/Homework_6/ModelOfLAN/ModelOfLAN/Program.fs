module Program

open ModelOfLAN

let model = new LocalNetwork("C:\Users\Альберт\Documents\GitHub\University\Fourth_semestr\Homework_6\ModelOfLAN\ModelOfLAN\matrix.txt", [2; 13])

[<EntryPoint>]
let main argv = 
    model.ShowAdjList()
    model.ShowSystem ()
    0 // возвращение целочисленного кода выхода
