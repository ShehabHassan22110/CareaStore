$(document).ready(() => {
	$("#sub").click(() => {
		let obj =
		{
			deviceId: $("#DeviceId").val(),
			isAndroiodDevice: true,
			title: $("#Title").val(),
			body: $("#Body").val()
		}
        console.log(obj);
		$.ajax({
			method: 'POST',
			url: '/Notafication/send',
			data: obj,
			success: function (res) {
				console.log(res);
			}
		})

	})

})
	

/*----------------------------------------*/
$(document).ready(() => {
	$("#Predict").click(() => {
		let obj =
		{
			doors: $("#Doors").val(),
			wheel: $("#Wheel").val(),
			levy: 100,
			engine_volume: 2.0,
			mileage: 5000,
			cylinders: 4,
			airbags: 6,
			model: $("#Model").val(),
			category: $("#Category").val(),
			leather_interior: $("#LeatherInterior").val(),
			fuel_type: $("#FuelType").val(),
			gear_box_type: $("#GearBoxType").val(),
			drive_wheels: $("#DriveWheels").val(),
			engine_turbo:1,
			age: 5,
			manufacturer: $("#Manufacturer").val(),
		}
		console.log(obj);
		$.ajax({
			method: 'POST',
			url: 'https://car-price-prediction-e99b.onrender.com/predict',
			data: obj,
			success: function (res) {
				console.log(res);
			}
		})

	})

})
