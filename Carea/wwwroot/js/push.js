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