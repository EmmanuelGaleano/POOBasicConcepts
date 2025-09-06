namespace BasicConcepts.Core;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    // Constructor por defecto
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    // Sobrecarga: hora
    public Time(int hour)
    {
        Hour = hour;
    }

    // Sobrecarga: hora y minuto
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    // Sobrecarga: hora, minuto y segundo
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    // Sobrecarga: hora, minuto, segundo y milisegundo
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour
    {
        get => _hour;
        set
        {
            if (value < 0 || value > 23)
                throw new Exception($"La hora: {value}, no es válida.");
            _hour = value;
        }
    }

    public int Minute
    {
        get => _minute;
        set
        {
            if (value < 0 || value > 59)
                throw new Exception($"Los minutos: {value}, no son válidos.");
            _minute = value;
        }
    }

    public int Second
    {
        get => _second;
        set
        {
            if (value < 0 || value > 59)
                throw new Exception($"Los segundos: {value}, no son válidos.");
            _second = value;
        }
    }

    public int Millisecond
    {
        get => _millisecond;
        set
        {
            if (value < 0 || value > 999)
                throw new Exception($"Los milisegundos: {value}, no son válidos.");
            _millisecond = value;
        }
    }

    // Convierte el tiempo a milisegundos
    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    // Convierte el tiempo a segundos
    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    // Convierte el tiempo a minutos
    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    // Suma otro tiempo (hora y minuto)
    public Time Add(Time other)
    {
        int newMinutes = ToMinutes() + other.ToMinutes();

        int newHour = (newMinutes / 60) % 24;
        int newMinute = newMinutes % 60;

        return new Time(newHour, newMinute, Second, Millisecond);
    }

    // Verifica si se pasa al siguiente día
    public bool IsNextDay(Time other)
    {
        int newMinutes = ToMinutes() + other.ToMinutes();
        return newMinutes >= 1440; // 1440 = minutos en un día
    }

    // Representación en texto
    public override string ToString()
    {
        return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {(Hour < 12 ? "AM" : "PM")}";
    }
}
