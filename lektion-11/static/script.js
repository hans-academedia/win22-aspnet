const signIn = async () => {
    const user = {
        'email': 'hans@domain.com',
        'password': 'BytMig123!'
    }
    
    const result = await fetch('https://localhost:7161/api/auth/sigin', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })

    if (result.status === 200) {
        const data = await result.text()
        console.log(data)
        localStorage.setItem('accessToken', data)
    }   
}


const getData = async () => {
    const result = await fetch('https://localhost:7161/api/Products', {
        headers: {
            'Authorization': `bearer ${localStorage.getItem('accessToken')}`
        }
    })

    if (result.status === 200) {
        const data = await result.json()
        console.log(data)
    }

}

signIn()
getData()