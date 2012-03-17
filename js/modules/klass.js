define("klass", ["students"], function(students){
	var self = {
		getStudentRoster: function(subject){
			var list = students.getEnrolled(subject);
			var html = $('<ul></ul>');
			$.each(list, function(i, item){
				html.append('<li>' + item + '</li>');
			});
			return html;
		}
	};
	
	return self;
});