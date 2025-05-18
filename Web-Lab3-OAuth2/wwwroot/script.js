async function fetchStatus(url) {
    const response = await fetch(url)

    if (response.status === 401) {
        const signInBtn = document.querySelector('#signInBtn')
        signInBtn.style.display = 'block'
    }

    const data = await response.json()

    const statusElement = document.querySelector('#userStatus')
    statusElement.innerText = data.status

    if (data.status === 'Logged in') {
        const infoSection = document.querySelector('#info')
        
        const userData = infoSection.querySelector('#userData')
        userData.innerText = await fetchStringData('/user/info')

        infoSection.style.display = 'block'
    }
}

async function fetchStringData(url) {
    const response = await fetch(url)

    if (!response.ok) {
        throw new Error('Network response was not ok')
    }

    const data = await response.json()
    return JSON.stringify(data, null, 2)
}

fetchStatus('/auth/status')