define("students", [], function(){
	var enrolledStudents;
	
	var self = {
		_init: function(){
			enrolledStudents = {
				math: ['John', 'Carl', 'Joseph'],
				chemistry: ['Rich', 'Alex']
			};
		},
		getEnrolled: function(subject){
			return enrolledStudents[subject];
		}
	};
	
	self._init();
	
	return self;
});