var selectedIndex = -1;
var self = this;

$(document).ready(function () {
    $(window).click(function () {
        $(".autocomplete").each(function (index, el) {
            lostFocus(el);
        });
    });

    $(".autocomplete>input[type='text']").on("input", function (ev) {
        run(ev.target);
    });

    $(".autocomplete>input[type='text']").on("keydown", function (e) {
        var parent = e.target.parentElement;

        if (e.keyCode === 9 && self.selectedIndex === -1) {
            lostFocus(e.target.parentElement);
            return true;
        }

        if (e.keyCode === 13 || e.keyCode === 9) {
            if (self.selectedIndex > -1) {
                item_select($(".result>ul>li.active").get(0), null);
            }
        }

        $(".result>ul>li", $(parent)).removeClass("active");

        if (e.keyCode === 38) {
            self.selectedIndex--;
            if (self.selectedIndex <= 0) {
                self.selectedIndex = $(".result>ul>li", $(parent)).length - 1;
            }
            $($(".result>ul>li", $(parent)).get(self.selectedIndex)).addClass("active");
        }

        if (e.keyCode === 40) {
            self.selectedIndex++;
            if (self.selectedIndex >= $(".result>ul>li", $(parent)).length) {
                self.selectedIndex = 0;
            }
            $($(".result>ul>li", $(parent)).get(self.selectedIndex)).addClass("active");
        }
    });
});

function run(filtro) {
    var autocompleteRoot = filtro.parentElement;
    self.selectedIndex = -1;
    $.get("Services/WSPaises.asmx/GetPaises?filtro=" + filtro.value, function (data) {
        var lista = "";
        if (data.length > 0) {
            $(".result", $(autocompleteRoot)).css("display", "block");
            for (var i = 0; i < data.length; i++) {
                lista += "<li onclick=\"item_select(this,event)\" data-id=\"" + data[i].Id + "\">" + data[i].Nombre + "</li>";
            }
            $(".result", $(autocompleteRoot)).html("<ul>" + lista + "</ul>");
        } else {
            $(".result", $(autocompleteRoot)).css("display", "none");
        }
    });
}

function item_select(item, ev) {
    var autocompleteRoot = item.parentElement.parentElement.parentElement;

    $("input[type='text']", $(autocompleteRoot)).val($(item).html());
    $($("input[type='hidden']", $(autocompleteRoot))[0]).val($(item).attr("data-id"));
    $($("input[type='hidden']", $(autocompleteRoot))[1]).val($(item).html());
    $(".result", $(autocompleteRoot)).html("");
    $(".result").css("display", "none");
    if (ev !== null) {
        ev.stopPropagation();
    }
}

function lostFocus(el) {
    if ($(".result", el).css("display") === "block") {
        $(".result").css("display", "none");
    }

    var texto = $($("input[type='hidden']", $(el))[1]).val();
    $("input[type='text']", $(el)).val(texto);
}