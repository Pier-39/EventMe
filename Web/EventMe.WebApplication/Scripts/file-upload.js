//read uplaoded photo content and title
function readURL(input) {
    var FILE_SIZE = 559959;

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        var file = input.files[0];

        reader.onload = function (e) {
            $('.upload-shitt-photo-div').show();
            $('.uploaded-image-content').show();
            $('.uploaded-image-content').attr('src', e.target.result);
            $('.image-title').attr('value', file.name);

        };

        reader.readAsDataURL(input.files[0]);

        // alert user if image size is too big
        if (file.size >= FILE_SIZE) {
            $('.upload-file-size-alert').show();
            $('.submit-post-disable').attr("disabled", true);
            $('.image-title').attr('value', file.name);
        }

        // alert user if iamge format is not allowed
        if (!file.type.match(/image\/.*/)) {
            $('.upload-file-format-alert').show();
            $('.submit-post-disable').attr("disabled", true);
            $('.image-title').attr('value', file.name);
        }
    }
}
