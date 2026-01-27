          select p.IdRol,p.NombreMenu from PERMISO p
               inner join rol r on r.IdRol = p.IdRol
   inner join USUARIO u on u.IdRol = r.IdRol
 where u.IdUsuario = @IdUsuario