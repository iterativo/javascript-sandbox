var studentsStub = { getEnrolled: function(subject){} };
define("students", [], studentsStub);
		
require(["klass"], function(klass){
	describe('klass module', function(){
		it('should get students roster list per class', function(){
			spyOn(studentsStub, 'getEnrolled').andCallFake(function(subject){
				if (subject === 'foo')
					return ['Joe', 'Richard'];
			});
			expect(klass.getStudentRoster('foo')).toHaveHtml('<li>Joe</li><li>Richard</li>');
		});
	});
});