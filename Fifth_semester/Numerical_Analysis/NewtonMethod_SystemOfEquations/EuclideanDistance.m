% computes Euclidean distance between vectos u and v
function [ distance ] = EuclideanDistance( u, v )
    if (length(u) ~= length(v))
        display('Vectors have different size');
    end
    
    S = 0;
    for i = 1 : length(u)
        S = S + (u(i) - v(i)) ^ 2;
    end
    distance = sqrt(S);
end

