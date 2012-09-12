function [posValVector] = impConsist(Mat)
%   Mejora la consistencia de las matrices AHP
%   Esta función calcula la inconsistencia generada en por cada valor de
%   la matriz y devuelve la lista de valores que deberían cambiarse
%   para mejorar la consistencia

VectorSaaty = [1/9 1/8 1/7 1/6 1/5 1/4 1/3 1/2 1 2 3 4 5 6 7 8 9];

[filas, columnas] = size(Mat);
dimension = filas;

[autovectores, autovalores] = eig(Mat);

valores = max(autovalores);
[autovalor, posicion] = max(valores);
autovector = autovectores (:, posicion);
suma = sum(autovector);
autovector = (autovector / suma);

fila = 1; columna = 2;
for fil = fila : dimension
    for col = columna : dimension
        idealesMatriz (fil, col) = autovector(fil) / autovector (col);
        idealesMatriz (col, fil) = 1 / idealesMatriz (fil, col);
    end
    columna = columna + 1;
end
idealesMatriz = idealesMatriz + eye(dimension);

diferenciaMatriz = abs(Mat - idealesMatriz);

for i = 1:dimension
    idealesMatriz(i, i)= -Inf;
end

filaMatSugeridos = 1;
for i = 1:dimension
    for j = 1:dimension
        if (i ~= j)

            [f,c]=find(diferenciaMatriz==max(max(diferenciaMatriz)));
            diferenciaMatriz(f, c) = -inf;

            Mat(f(1),c(1)) = 0; Mat(c(1),f(1)) = 0;
            Mat(f(1),f(1)) = 2; Mat(c(1),c(1)) = 2;

            [autovectores, autovalores] = eig(Mat);

            valores = max(autovalores);
            [autovalor, posicion] = max(valores);
            autovector = autovectores (:, posicion);
            suma = sum(autovector);
            autovector = (autovector / suma);

            [minimo, posMinimo] = min(abs(VectorSaaty - (autovector(f(1))/autovector(c(1)))));

            sugerido(filaMatSugeridos, 1) = f;
            sugerido(filaMatSugeridos, 2) = c;
            sugerido(filaMatSugeridos, 3) = VectorSaaty(posMinimo);
            
            filaMatSugeridos = filaMatSugeridos + 1;

        end
    end
end

posValVector = sugerido;

end
