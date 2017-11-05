% Prints the table of the divided differences
% for y = f(x) for given array x.
function [ ] = Display2( )
x = [0.5 0.6 0.4 0.7 0.3];
x = sort(x);
for i = 1 : length(x)
    y(i) = f(x(i));
end

table = DividedDifferences(x, y, length(x));
table(:,1) = [ ];
display(table);
end