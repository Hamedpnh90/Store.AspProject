function loadingpage() {
    let timerInterval
    Swal.fire({
        title: 'در حال بارگذاری ...',
        html: 'متظر بمانید ...<b></b> ثانیه تا بارگذاری',
        timer: 3000,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
            const b = Swal.getHtmlContainer().querySelector('b')
            timerInterval = setInterval(() => {
                b.textContent = Swal.getTimerLeft()
            }, 100)
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        /* Read more about handling dismissals below */
        if (result.dismiss === Swal.DismissReason.timer) {
            console.log('I was closed by the timer')
        }
    })

   
}





  
function subEmail() {

  
        $.ajax({
            url: "/home/Submitemail/",
            type: "POST",
            dataType: "json",
            data: { Emailval: $('#Emailval').val() },


            success: function (res) {
                console.log(res);
                if (res.status ==="success") {
                    Swal.fire({
                        position: 'bottom-start',
                        icon: 'success',
                        title: 'ایمیل شمل با موفقیت ثبت شد',
                        showConfirmButton: false,
                        timer: 2500
                    })
                } else {
                    Swal.fire({
                        position: 'bottom-bottom',
                        icon: 'error',
                        title: 'مشکلی در ثبت ایمیل رخ داد',
                        showConfirmButton: false,
                        timer: 2500
                    })
                }
            },

            Error: function (res) {


                alert("failed");

            }
        });

    }


function EmailSuccess() {

    if (res.success==='success') {


        ShowMessage('عملیات با موفقیت انجام شد', 'موفق', 'SuccessMsg')

    }
    else {
        ShowMessage('عملیات باشکست مواجه شد', 'خطا', 'ErrorMsg')
    }
}