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
			levy: $("#Levy").val(),
			engine_volume: $("#EngineVolume").val(),
			mileage: $("#Mileage").val(),
			cylinders: $("#Cylinders").val(),
			airbags: $("#Airbags").val(),
			model: $("#Model").val(),
			category: $("#Category").val(),
			leather_interior: $("#LeatherInterior").val(),
			fuel_type: $("#FuelType").val(),
			gear_box_type: $("#GearBoxType").val(),
			drive_wheels: $("#DriveWheels").val(),
			engine_turbo: $("#EngineTurbo").val(),
			age: $("#Age").val(),
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
