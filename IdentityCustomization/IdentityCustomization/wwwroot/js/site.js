(function () {
    "use strict";

    $(document).ready(() => {
        const categorySelect = $("#Input_Category");
        if (categorySelect) {
            updateRequiredFields(categorySelect);
            categorySelect.change(() => {
                updateRequiredFields(categorySelect);
            });
        }
    });

    function updateRequiredFields(categorySelect) {
        const organizationInput = $("#Input_Organization");
        const belongsToInput = $("#Input_BelongsTo");
        const category = parseInt(categorySelect.val());
        if (category <= 1) {
            organizationInput.attr("disabled", false);
            organizationInput.rules("add", {
                required: true,
                messages: {
                    required: "The Organization field is required."
                }
            });

            belongsToInput.val("");
            belongsToInput.rules("remove", "required");
            belongsToInput.valid();
            belongsToInput.attr("disabled", true);
        } else {
            belongsToInput.attr("disabled", false);
            belongsToInput.rules("add", {
                required: true,
                messages: {
                    required: "The Belongs to field is required."
                }
            });

            organizationInput.val("");
            organizationInput.rules("remove", "required");
            organizationInput.valid();
            organizationInput.attr("disabled", true);
        }
    }
}());
