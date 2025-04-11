import { PersonCrew } from '../../../interfaces/movies/person-crew.interface';
import { Messages } from '../../../Messages';
import classes from './Crew.module.css';

interface CrewProps {
  crew: PersonCrew[];
}

function Crew(props: CrewProps) {
  return (
    <>
      <h5>Crew:</h5>
      <div className={classes.crewContainer}>
        {props.crew.length > 0 ? (
          <ul>
            {props.crew.map((crewMember, index) => (
              <li key={index}>
                <strong>{crewMember.name}</strong>{' '}
                {crewMember.character && ` - ${crewMember.character}`} (
                {crewMember.department})
              </li>
            ))}
          </ul>
        ) : (
          <p>{Messages.NoMovieCrewAvailable}</p>
        )}
      </div>
    </>
  );
}

export default Crew;
