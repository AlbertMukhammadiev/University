﻿module Program

open ModelOfLAN

let model = new LocalNetwork([2; 13])

[<EntryPoint>]
let main argv = 
    model.ShowAdjList()
    model.ShowSystem ()
    0 // возвращение целочисленного кода выхода
