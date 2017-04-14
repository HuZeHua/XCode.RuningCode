(function() {
    $("#loginForm").validate({
        submitHandler:function(form) {
            $(form).find("button[type='submit']:first").button("loading").queue(function() {
                form.submit();
            });
        },
		rules: {
			LoginName: {
				required: true,
				minlength: 2
			},
			Password: {
				required: true,
				minlength: 6
			}
		},
		messages: {
			LoginName: {
				required: "请输入登录账号",
				minlength: "登录账号最小长度为2个字符"
			},
			Password: {
				required: "请输入登录密码",
				minlength: "登录账号最小长度为6个字符"
			}
		}
	});
})();