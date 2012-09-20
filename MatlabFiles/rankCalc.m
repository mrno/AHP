function [ranking] = rankCalc(cel)
%   Esta función calcula el ranking final AHP para las alternativas

%   Determina el tamaño del cellarray
[f, cant] = size(cel);

for iter = 1:cant
    
    Mat = cell2mat(cel(iter));
    [filas, columnas] = size(Mat);
    dimension = filas;

    [autovectores, autovalores] = eig(Mat);

    valores = max(autovalores);
    [autovalor, posicion] = max(valores);
    autovector = autovectores (:, posicion);
    suma = sum(autovector);
    autovector = (autovector / suma);
    
    if (iter == 1)
        vectCriterios = autovector;
    else    
        matVectAlter = 1;
    end
    
end
%*  vectCriterios
ranking =matVectAlter;

end