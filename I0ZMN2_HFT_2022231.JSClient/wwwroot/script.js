let RentCar = [];
let connection = null;


let RentCarIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48540/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RentCarCreated", (user, message) => {
        getdata();
    });

    connection.on("RentCarDeleted", (user, message) => {
        getdata();
    });

    connection.on("RentCarUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


fetch('http://localhost:48540/RentCar')
    .then(x => x.json())
    .then(y =>
    {
        RentCar = y;
        console.log(RentCar);
        display();
    });

async function getdata() {
    await fetch('http://localhost:48540/RentCar')
        .then(x => x.json())
        .then(y => {
            RentCar = y;
            //console.log(RentCar);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    RentCar.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.BuyerName + "</td><td>"
            + t.BrandName + "</td><td>"
            + t.car_id + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>`+
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}



function create() {
    let BuyDate = document.getElementById('BuyDate').value;
    let BuyerName = document.getElementById('BuyerName').value;
    let carid = document.getElementById('carid').value;
    fetch('http://localhost:48540/RentCar', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { BuyDate: BuyDate, BuyerName: BuyerName, car_id: carid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:48540/RentCar/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });        
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let BuyDate = document.getElementById('BuyDatetoupdate').value;
    let BuyerName = document.getElementById('BuyerNametoupdate').value;
    let carid = document.getElementById('caridtoupdate').value;
    fetch('http://localhost:48540/RentCar', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { BuyDate: BuyDate, BuyerName: BuyerName, car_id: carid, id: RentCarIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function showupdate(id) {
    document.getElementById('BuyDatetoupdate').value = RentCar.find(t => t['id'] == id)['BuyDate'];
    document.getElementById('BuyerNametoupdate').value = RentCar.find(t => t['id'] == id)['BuyerName'];
    document.getElementById('caridtoupdate').value = RentCar.find(t => t['id'] == id)['carid'];
    document.getElementById('updateformdiv').style.display = 'flex';
    RentCarIdToUpdate = id;
}