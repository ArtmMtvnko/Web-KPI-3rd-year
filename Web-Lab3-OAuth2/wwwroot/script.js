﻿async function fetchStatus(url) {
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

const binanceResponseProtobufSchema = `
    syntax = "proto3";

    message BinanceResponseProtobuf {
        string stream = 1;
        BinanceDataProtobuf data = 2;
    }

    message BinanceDataProtobuf {
        string symbol = 1;
        string priceChange = 2;
        string priceChangePercent = 3;
        string lastPrice = 4;
    }
`

let websocket;

function startStreaming() {
    const websocketUrl = new URL('wss://localhost:5443/ws')
    websocket = new WebSocket(websocketUrl)

    websocket.binaryType = 'arraybuffer'

    const root = protobuf.parse(binanceResponseProtobufSchema).root
    const BinanceResponseProtobuf = root.lookupType('BinanceResponseProtobuf')

    websocket.onopen = () => {
        console.log('Websocket connection established')
        
        const startSteamingBtn = document.querySelector('.start_stream_btn')
        startSteamingBtn.style.display = 'none'
        
        const stopSteamingBtn = document.querySelector('.stop_stream_btn')
        stopSteamingBtn.style.display = 'block'
    }
    
    const currencyBoard = document.getElementById('currencyBoard')

    websocket.onmessage = (event) => {
        // const data = JSON.parse(event.data)
        const buffer = new Uint8Array(event.data)
        const data = BinanceResponseProtobuf.decode(buffer)
        console.log('Received data:', event.data)
        console.log('Decoded data:', data)

        const elem = currencyBoard.querySelector(`#${data.data.symbol}`)

        if (elem) {
            const priceChange = round(parseFloat(data.data.priceChange), 4)

            if (priceChange > 0) {
                elem.style.backgroundColor = '#baffb5' // light green
            } else if (priceChange < 0) {
                elem.style.backgroundColor = '#fcbebb' // light red
            } else {
                elem.style.backgroundColor = 'transparent'
            }

            const currencyName = data.data.symbol.slice(0, data.data.symbol.length - 4)
            const priceChangeText = priceChange < 0 ? `(${priceChange})` : `(+${priceChange})`

            elem.innerText = `${currencyName} ${round(data.data.lastPrice, 2)} ${priceChangeText}`
        } else {
            const newElem = document.createElement('div')
            newElem.id = data.data.symbol

            const currencyName = data.data.symbol.slice(0, data.data.symbol.length - 4)
            newElem.innerText = `${currencyName} ${round(data.data.lastPrice, 2)} ${round(data.data.priceChange, 2)}`
            newElem.style.border = '1px solid black'
            newElem.style.padding = '5px'
            newElem.style.margin = '5px'

            currencyBoard.appendChild(newElem)
        }
    }

    websocket.onclose = () => {
        console.log('Websocket connection closed')

        const startSteamingBtn = document.querySelector('.start_stream_btn')
        startSteamingBtn.style.display = 'block'
        
        const stopSteamingBtn = document.querySelector('.stop_stream_btn')
        stopSteamingBtn.style.display = 'none'
    }
}

function stopStreaming() {
    if (!websocket || websocket.readyState !== WebSocket.OPEN) {
        console.log('Websocket is not open')
        return
    }

    websocket.close()
}

function round(number, precision) {
    if (typeof number === 'string') {
        const factor = Math.pow(10, precision)
        return Math.round(parseFloat(number) * factor) / factor
    } else if (typeof number === 'number') {
        const factor = Math.pow(10, precision)
        return Math.round(number * factor) / factor
    } else {
        throw new Error('Invalid number type')
    }
}
