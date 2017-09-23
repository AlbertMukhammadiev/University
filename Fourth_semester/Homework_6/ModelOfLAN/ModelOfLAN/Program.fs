module Program

open ModelOfLAN

let input = "wllowlwowlolwow\n010011000000000\n101010000000000\n010110000000000\n001010101000000\n111100000000000\n100000010100000\n000100001010000\n000001001001000\n000100110000000\n000001000001100\n000000100001001\n000000010110000\n000000000100010\n000000000000101\n000000000010010"
let model = new LocalNetwork([2; 13], input)

[<EntryPoint>]
let main argv = 
    printf "%A" input
    model.ShowAdjList()
    model.ShowSystem ()
    model.Step()
    model.ShowSystem()
    model.Step()
    model.ShowSystem()
    0 // возвращение целочисленного кода выхода
