namespace CodeChecking

type Class1() = 
    member this.X = "F#"


module HKConc = 

    // f_cu should only range from 20-100
    // Concrete strength 
    let e_cu f_cu =
        match f_cu < 60.0 with 
            | true -> (0.0035)
            | false -> (0.0035 - 0.00006 * (f_cu-60.0)**0.5)
        
    let e_d f_cu = 1000.0 * (3.46 * (f_cu/1.5)**0.5 + 3.21)

    let e_c0 f_cu = 1.34 * f_cu / 1.5 / (e_d f_cu)

    let f_max f_cu = 0.67 * f_cu / 1.5

    // Concrete stress-strain relationship
    let ConcStress x f_cu = 
        (f_max f_cu) * (
            if x <= 0.0 then 0.0 
            elif x < (e_c0 f_cu) then 1.0 - (x / (e_c0 f_cu) - 1.0)**2.0 
            elif x < (e_cu f_cu) then 1.0 
            else 0.0)