
$(document).ready(function () {
	$("#dataTable").kendoGrid({
		dataSource: {
			type: "odata",
			transport: {
				read: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
			},
			pageSize: 20
		},
		groupable: true,
		sortable: {
			mode: "single",
			allowUnsort: false
		},
		//sortable: true,
		pageable: {
			refresh: true,
			pageSizes: true,
			buttonCount: 5
		},
		columns: [{
			field: "ContactName",
			title: "Contact Name",
			width: 200
		}, {
			field: "ContactTitle",
			title: "Contact Title",
			width: 250
		}, {
			field: "CompanyName",
			title: "Company Name"
		}, {
			field: "Country",
			width: 150
		}]
	});

	$('.datepicker').datepicker({
		format: 'mm/dd/yyyy',
	});
});

$( window ).load(function() {
	$('.nav .select').addClass('active');
});
