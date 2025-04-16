async function Execution(){


    //2
    console.group('Task 2')

    let myPromise = new Promise(function(resolve, reject){
        setTimeout(() => resolve(Math.round(Math.random()*100)), 3000);
    })

        await myPromise.then(
            result => console.log(result)
        )

        console.groupEnd()
        
        
    //3
    console.group('Task 3')

    function delay(delay: number){
        return new Promise(resolve => setTimeout(() => resolve(Math.round(Math.random()*100)), delay))
    }

    await Promise.all([delay(4000), delay(1000), delay(2000)]).then(result=>{
        console.log(result)
    }) 
    console.groupEnd()


    //4
    console.group('Task 4')

    let pr = new Promise((res,rej) => {
        rej('ku')
    })

        await pr
        .then(() => console.log(1))
        .catch(() => console.log(2))
        .catch(() => console.log(3))
        .then(() => console.log(4))
        .then(() => console.log(5)) // 2, 4, 5
    
    console.groupEnd()

    //5
    console.group('Task 5')
    
    let promiseTask5 = new Promise(resolve => {
        resolve(21);
    })

    await promiseTask5
    .then(res => {
        console.log(res)
        if(typeof(res) == 'number')
        return res * 2;
    })
    .then(
        res => console.log(res)
    )

    console.groupEnd()


    //6
    console.group('Task 6');

    let result1 =  await promiseTask5;
    console.log(result1)


    let result2;
    if(typeof(result1) =='number')
    result2 = result1 * 2;

    console.log(result2)
    console.groupEnd();
}


Execution()