function AutoComplete(Id, Url, NoResultClass, DependentFilter = null, isStreet = false) {
    $(Id).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: Url,
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term,
                    isStreet: isStreet,
                    cityPrefix: $("#City").val()
                },
                success: function (data) {
                    if (!data.length) {
                        $(NoResultClass).show();
                        response();
                    } else {
                        response($.map(data, function (item) {
                            $(NoResultClass).hide();
                            return { label: item.Name_He, value: item.Name_He };
                        }))
                    }
                }, error: function () {
                    alert('something went wrong !');
                }
            })
        },
        select: function (event, ui) {
            $(DependentFilter).prop("disabled", false);
        }
    });
}

