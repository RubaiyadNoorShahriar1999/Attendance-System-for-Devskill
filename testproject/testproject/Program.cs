using testProject;

testProjectDbContext test = new testProjectDbContext();
Student s1 = new Student();
s1.Name= "Test";
s1.Description= "This is a test";

test.Add(s1);
test.SaveChanges();