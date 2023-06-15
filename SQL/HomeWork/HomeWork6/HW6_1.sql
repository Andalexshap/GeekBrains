use lesson_4;

create table users_old like users;

drop procedure if exists move_user;
delimiter //
create procedure move_user(in user_id int)
begin
    start transaction;
    insert into users_old
        select * from users where id = user_id;
    delete from users
        where id = user_id;

    if row_count() = 1 then
        commit;
        select 'OK';
    else
        rollback;
        select 'ERROR';
    end if;
end //
delimiter ;

call move_user(2);

select * from users_old;