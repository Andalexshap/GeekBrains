DROP FUNCTION IF EXISTS user_popularity_coefficient;
CREATE FUNCTION user_popularity_coefficient(id_researches_user BIGINT UNSIGNED)
RETURNS DOUBLE READS SQL DATA
BEGIN
	DECLARE to_user int;
    DECLARE from_user int;
    DECLARE user_popularity_coefficient DOUBLE;

    SET to_user = (SELECT COUNT(*) FROM friend_requests WHERE target_user_id = id_researches_user);
    SET from_user = (SELECT COUNT(*) FROM friend_requests WHERE initiator_user_id = id_researches_user);

		IF (from_user = 0) THEN SET user_popularity_coefficient = NULL;
		ELSE SET user_popularity_coefficient = to_user / from_user ;
		END IF;

    RETURN user_popularity_coefficient ;
END;

select user_popularity_coefficient(6)