using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using TruckSimulatorTemplate;

/// <summary>
/// This script controls the playerTruck.
/// Location: on each playerTruck prefab on the "Front__.sc" gameObject.
/// </summary>


namespace TruckSimulatorTemplate
{
    public enum ControlMode { keyboard = 1, mobile = 2 }

    public class TruckController : MonoBehaviour
    {

        public ControlMode controlMode = ControlMode.keyboard;

        public bool automaticGear = true;
        public ConnectWheel wheelMeshes;

        [System.Serializable]
        public class ConnectWheel
        {
            [HideInInspector]
            public bool frontWheelDrive = true;
            [HideInInspector]
            public bool backWheelDrive = true;
            public Transform frontRightMesh;
            public Transform frontLeftMesh;
            public Transform rearRightMesh;
            public Transform rearLeftMesh;
            public Transform[] anyExtraMesh;

        }

        public float wheelRadius = 0.5f;

        public float wheelWeight = 1000.0f;
        public float wheelStiffness = 2.0f;

        public float suspensionDistance = 0.2f;
        public Light[] frontLights;
        public Light[] brakeLights;
        public Light[] reverseLights;


        public AudioSource IdleEngine, LowEngine, HighEngine;
        public AudioSource switchGear;

        public GameObject brakeParticlePrefab;
        public ParticleSystem shiftParticle1, shiftParticle2;
        private GameObject[] wheelParticle = new GameObject[4];

        public Transform carSteer;

        public List<Transform> differentCameraViews;
        [HideInInspector]
        public float springs = 25000.0f;
        [HideInInspector]
        public float dampers = 1500.0f;

        public float speedTorque = 120f;
        public float forwardForce = 200000f;
        public float shiftPower = 150f;
        public float brakePower = 8000f;

        public Vector3 shiftCentre = new Vector3(0.0f, -0.8f, 0.0f);

        public float maxSteerAngle = 25.0f;
        [HideInInspector]
        public float shiftDownRPM = 1500.0f;
        [HideInInspector]
        public float shiftUpRPM = 2500.0f;
        [HideInInspector]
        public float idleRPM = 500.0f;

        public float[] gears = { -10f, 9f, 6f, 4.5f, 3f, 2.5f };

        public float LimitBackwardSpeed = 60.0f;
        public float LimitForwardSpeed = 220.0f;


        public float steer = 0;
        private float accel = 0.0f;
        [HideInInspector]
        public bool brake;

        private bool shifmotor;

        [HideInInspector]
        public float curTorque = 100f;
        [HideInInspector]
        public float powerShift = 100;
        [HideInInspector]
        public bool shift;

        private float torque = 100f;


        [HideInInspector]
        public float speed = 0.0f;

        private float lastSpeed = -10.0f;


        private bool shifting = false;


        float[] efficiencyTable = { 0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 1.0f, 1.0f, 0.95f, 0.80f, 0.70f, 0.60f, 0.5f, 0.45f, 0.40f, 0.36f, 0.33f, 0.30f, 0.20f, 0.10f, 0.05f };


        float efficiencyTableStep = 250.0f;



        private float Pitch;
        private float PitchDelay;

        private float shiftTime = 0.0f;

        private float shiftDelay = 0.0f;


        [HideInInspector]
        public int currentGear = 0;
        [HideInInspector]
        public bool NeutralGear = true;

        [HideInInspector]
        public float motorRPM = 0.0f;

        [HideInInspector]
        public bool Backward = false;

        ////////////////////////////////////////////// TouchMode (Control) ////////////////////////////////////////////////////////////////////


        [HideInInspector]
        public float accelFwd = 0.0f;
        [HideInInspector]
        public float accelBack = 0.0f;
        [HideInInspector]
        public float steerAmount = 0.0f;


        private float wantedRPM = 0.0f;
        private float w_rotate;
        private float slip, slip2 = 0.0f;


        private GameObject[] Particle = new GameObject[4];

        private Vector3 steerCurAngle;

        Rigidbody rigidBody;

        private WheelComponent[] wheels;

        private class WheelComponent
        {

            public Transform wheel;
            public WheelCollider collider;
            public Vector3 startPos;
            public float rotation = 0.0f;
            public float rotation2 = 0.0f;
            public float maxSteer;
            public bool drive;
            public float pos_y = 0.0f;
        }


        private WheelComponent SetWheelComponent(Transform wheel, float maxSteer, bool drive, float pos_y)
        {

            WheelComponent result = new WheelComponent();
            GameObject wheelCol = new GameObject(wheel.name + "WheelCollider");

            wheelCol.transform.parent = transform;
            wheelCol.transform.position = wheel.position;
            wheelCol.transform.eulerAngles = transform.eulerAngles;
            pos_y = wheelCol.transform.localPosition.y;

            WheelCollider col = (WheelCollider)wheelCol.AddComponent(typeof(WheelCollider));

            result.wheel = wheel;
            result.collider = wheelCol.GetComponent<WheelCollider>();
            result.drive = drive;
            result.pos_y = pos_y;
            result.maxSteer = maxSteer;
            result.startPos = wheelCol.transform.localPosition;

            return result;

        }
        bool shiftupbool = false;
        bool shiftdownbool = false;

        private Vector3 colPointToMe;
        private float colStrength;

        public float YforceDamp = 0.1f; // 0.0 - 1.0
        Transform target;

        [HideInInspector]
        public int Switch;
        [HideInInspector]
        public bool stopTruck = false;

        void CallLater()
        {
            if (GameData.GetTimeOfDay() == 1 || GameData.GetTimeOfDay() == 2)
            {
                frontLights[0].gameObject.SetActive(true);
                frontLights[1].gameObject.SetActive(true);

            }
            else
            {
                frontLights[0].gameObject.SetActive(false);
                frontLights[1].gameObject.SetActive(false);
            }
        }
        void Awake()
        {
            Invoke("CallLater", 0.6f);


            rigidBody = transform.GetComponent<Rigidbody>();
            target = rigidBody.transform;
            if (automaticGear) NeutralGear = false;

            wheels = new WheelComponent[4];

            wheels[0] = SetWheelComponent(wheelMeshes.frontRightMesh, maxSteerAngle, wheelMeshes.frontWheelDrive, wheelMeshes.frontRightMesh.position.y);
            wheels[1] = SetWheelComponent(wheelMeshes.frontLeftMesh, maxSteerAngle, wheelMeshes.frontWheelDrive, wheelMeshes.frontLeftMesh.position.y);

            wheels[2] = SetWheelComponent(wheelMeshes.rearRightMesh, 0, wheelMeshes.backWheelDrive, wheelMeshes.rearRightMesh.position.y);
            wheels[3] = SetWheelComponent(wheelMeshes.rearLeftMesh, 0, wheelMeshes.backWheelDrive, wheelMeshes.rearLeftMesh.position.y);

            if (carSteer)
                steerCurAngle = carSteer.localEulerAngles;

            foreach (WheelComponent w in wheels)
            {

                WheelCollider col = w.collider;
                col.suspensionDistance = suspensionDistance;
                JointSpring js = col.suspensionSpring;

                js.spring = springs;
                js.damper = dampers;
                col.suspensionSpring = js;


                col.radius = wheelRadius;

                col.mass = wheelWeight;


                WheelFrictionCurve fc = col.forwardFriction;

                fc.asymptoteValue = 5000.0f;
                fc.extremumSlip = 2.0f;
                fc.asymptoteSlip = 20.0f;
                fc.stiffness = wheelStiffness;
                col.forwardFriction = fc;
                fc = col.sidewaysFriction;
                fc.asymptoteValue = 7500.0f;
                fc.asymptoteSlip = 2.0f;
                fc.stiffness = wheelStiffness;
                col.sidewaysFriction = fc;


            }


        }




        public void ShiftUp()
        {
            float now = Time.timeSinceLevelLoad;

            if (now < shiftDelay) return;

            if (currentGear < gears.Length - 1)
            {

                // if (! switchGear.isPlaying)
                switchGear.GetComponent<AudioSource>().Play();


                if (!automaticGear)
                {
                    if (currentGear == 0)
                    {
                        if (NeutralGear) { currentGear++; NeutralGear = false; }
                        else
                        { NeutralGear = true; }
                    }
                    else
                    {
                        currentGear++;
                    }
                }
                else
                {
                    currentGear++;
                }


                shiftDelay = now + 1.0f;
                shiftTime = 1.5f;
            }
        }




        public void ShiftDown()
        {
            float now = Time.timeSinceLevelLoad;

            if (now < shiftDelay) return;

            if (currentGear > 0 || NeutralGear)
            {

                //w if (! switchGear.isPlaying)
                switchGear.GetComponent<AudioSource>().Play();

                if (!automaticGear)
                {

                    if (currentGear == 1)
                    {
                        if (!NeutralGear) { currentGear--; NeutralGear = true; }
                    }
                    else if (currentGear == 0) { NeutralGear = false; } else { currentGear--; }
                }
                else
                {
                    currentGear--;
                }


                shiftDelay = now + 0.1f;
                shiftTime = 2.0f;
            }
        }



        void OnCollisionEnter(Collision collision)
        {

            if (collision.transform)
            {

                slip2 = Mathf.Clamp(collision.relativeVelocity.magnitude, 0.0f, 10.0f);

                rigidBody.angularVelocity = new Vector3(-rigidBody.angularVelocity.x * 0.5f, rigidBody.angularVelocity.y * 0.5f, -rigidBody.angularVelocity.z * 0.5f);
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f, rigidBody.velocity.z);



            }

        }

        void OnCollisionStay(Collision collision)
        {

            if (collision.transform)
                slip2 = 5.0f;

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Update()
        {
            if(stopTruck)
            {
                rigidBody.drag = 5f;
            }

            if (!automaticGear)
            {
                if (Input.GetKeyDown(KeyCode.K) || shiftupbool)
                {
                    ShiftUp();
                    shiftupbool = false;

                }
                if (Input.GetKeyDown(KeyCode.L) || shiftdownbool)
                {
                    ShiftDown();
                    shiftdownbool = false;

                }
            }

        }

        public void shiftupgear()
        {
            shiftupbool = true;
        }

        public void shiftdowngear()
        {
            shiftdownbool = true;
        }


        void FixedUpdate()
        {


            // speed of car
            speed = rigidBody.velocity.magnitude * 2.7f;

            foreach (Transform extraWheel in wheelMeshes.anyExtraMesh)
            {
                extraWheel.transform.Rotate(100 * speed * Time.deltaTime, 0, 0);
            }

            rigidBody.AddRelativeForce(0, 0, forwardForce * Time.deltaTime * accel);


            if (speed < lastSpeed - 10 && slip < 10)
            {
                slip = lastSpeed / 15;
            }

            lastSpeed = speed;




            if (slip2 != 0.0f)
                slip2 = Mathf.MoveTowards(slip2, 0.0f, 0.1f);



            rigidBody.centerOfMass = shiftCentre;





            if (controlMode == ControlMode.keyboard)
            {


                accel = 0;
                brake = false;
                shift = false;

                if (wheelMeshes.frontWheelDrive || wheelMeshes.backWheelDrive)
                {
                    steer = Mathf.MoveTowards(steer, Input.GetAxis("Horizontal"), 0.2f);
                    accel = Input.GetAxis("Vertical");
                    brake = Input.GetButton("Jump");
                    shift = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);


                }

            }
            else if (controlMode == ControlMode.mobile && GameData.GetSelectedControltype() == "arrows")
            {

                if (accelFwd != 0)
                {
                    accel = accelFwd;
                    rigidBody.AddForce(transform.forward * Time.deltaTime, ForceMode.Acceleration);
                }
                else
                {
                    accel = accelBack;

                }
                steer = Mathf.MoveTowards(steer, steerAmount, 0.07f);

            }
            else if (controlMode == ControlMode.mobile && GameData.GetSelectedControltype() == "tilt")
            {

                if (accelFwd != 0)
                {
                    accel = accelFwd;
                    rigidBody.AddForce(transform.forward * Time.deltaTime, ForceMode.Acceleration);
                }
                else
                {
                    accel = accelBack;

                }
                steer = Mathf.MoveTowards(Input.acceleration.x, steerAmount, 0.07f);
            }
            else  
            {
                if (accelFwd != 0)
                {
                    accel = accelFwd;
                    rigidBody.AddForce(transform.forward * Time.deltaTime, ForceMode.Acceleration);
                }
                else
                {
                    accel = accelBack;

                }
               // steer = Mathf.MoveTowards(SimpleInput.GetAxis("Horizontal"), steerAmount, 0.07f);
            }



            if (!wheelMeshes.frontWheelDrive && !wheelMeshes.backWheelDrive)
                accel = 0.0f;



            if (carSteer)
                carSteer.localEulerAngles = new Vector3(steerCurAngle.x, steerCurAngle.y, steerCurAngle.z + (steer * -120.0f));



            if (automaticGear && (currentGear == 1) && (accel < 0.0f))
            {
                if (speed < 5.0f)
                    ShiftDown();


            }
            else if (automaticGear && (currentGear == 0) && (accel > 0.0f))
            {
                if (speed < 5.0f)
                    ShiftUp();

            }
            else if (automaticGear && (motorRPM > shiftUpRPM) && (accel > 0.0f) && speed > 10.0f && !brake)
            {

                ShiftUp();

            }
            else if (automaticGear && (motorRPM < shiftDownRPM) && (currentGear > 1))
            {
                ShiftDown();
            }



            if (speed < 1.0f) Backward = true;



            if (currentGear == 0 && Backward == true)
            {

                if (speed < gears[0] * -10)
                    accel = -accel;
            }
            else
            {
                Backward = false;

            }


            foreach (Light brakeLight in brakeLights)
            {
                if (brake || accel < 0 || speed < 1.0f)
                {
                    brakeLight.intensity = Mathf.MoveTowards(brakeLight.intensity, 8, 0.5f);
                }
                else
                {
                    brakeLight.intensity = Mathf.MoveTowards(brakeLight.intensity, 0, 0.5f);

                }

                brakeLight.enabled = brakeLight.intensity == 0 ? false : true;
            }


            foreach (Light WLight in reverseLights)
            {
                if (speed > 2.0f && currentGear == 0)
                {
                    WLight.intensity = Mathf.MoveTowards(WLight.intensity, 8, 0.5f);
                }
                else
                {
                    WLight.intensity = Mathf.MoveTowards(WLight.intensity, 0, 0.5f);
                }
                WLight.enabled = WLight.intensity == 0 ? false : true;
            }


            wantedRPM = (5500.0f * accel) * 0.1f + wantedRPM * 0.9f;

            float rpm = 0.0f;
            int motorizedWheels = 0;
            bool floorContact = false;
            int currentWheel = 0;

            foreach (WheelComponent w in wheels)
            {
                WheelHit hit;
                WheelCollider col = w.collider;

                if (w.drive)
                {
                    if (!NeutralGear && brake && currentGear < 2)
                    {
                        rpm += accel * idleRPM;

                    }
                    else
                    {
                        if (!NeutralGear)
                        {
                            rpm += col.rpm;
                        }
                        else
                        {
                            rpm += (idleRPM * accel);
                        }
                    }


                    motorizedWheels++;
                }




                if (brake || accel < 0.0f)
                {

                    if ((accel < 0.0f) || (brake && (w == wheels[2] || w == wheels[3])))
                    {

                        if (brake && (accel > 0.0f))
                        {
                            slip = Mathf.Lerp(slip, 5.0f, accel * 0.01f);
                        }
                        else if (speed > 1.0f)
                        {
                            slip = Mathf.Lerp(slip, 1.0f, 0.002f);
                        }
                        else
                        {
                            slip = Mathf.Lerp(slip, 1.0f, 0.02f);
                        }


                        wantedRPM = 0.0f;
                        col.brakeTorque = brakePower;
                        w.rotation = w_rotate;

                    }
                }
                else
                {


                    col.brakeTorque = accel == 0 || NeutralGear ? col.brakeTorque = 1000 : col.brakeTorque = 0;


                    slip = speed > 0.0f ?
        (speed > 100 ? slip = Mathf.Lerp(slip, 1.0f + Mathf.Abs(steer), 0.02f) : slip = Mathf.Lerp(slip, 1.5f, 0.02f))
        : slip = Mathf.Lerp(slip, 0.01f, 0.02f);


                    w_rotate = w.rotation;

                }



                WheelFrictionCurve fc = col.forwardFriction;



                fc.asymptoteValue = 5000.0f;
                fc.extremumSlip = 2.0f;
                fc.asymptoteSlip = 20.0f;
                fc.stiffness = wheelStiffness / (slip + slip2);
                col.forwardFriction = fc;
                fc = col.sidewaysFriction;
                fc.stiffness = wheelStiffness / (slip + slip2);


                fc.extremumSlip = 0.2f + Mathf.Abs(steer);

                col.sidewaysFriction = fc;




                if (shift && (currentGear > 1 && speed > 50.0f) && shifmotor && Mathf.Abs(steer) < 0.2f)
                {

                    if (powerShift == 0) { shifmotor = false; }

                    powerShift = Mathf.MoveTowards(powerShift, 0.0f, Time.deltaTime * 10.0f);

                    curTorque = powerShift > 0 ? shiftPower : speedTorque;
                    //carParticles.shiftParticle1.emissionRate = Mathf.Lerp(carParticles.shiftParticle1.emissionRate, powerShift > 0 ? 50 : 0, Time.deltaTime * 10.0f);
                    //carParticles.shiftParticle2.emissionRate = Mathf.Lerp(carParticles.shiftParticle2.emissionRate, powerShift > 0 ? 50 : 0, Time.deltaTime * 10.0f);
                }
                else
                {

                    if (powerShift > 20)
                    {
                        shifmotor = true;
                    }


                    powerShift = Mathf.MoveTowards(powerShift, 100.0f, Time.deltaTime * 5.0f);
                    curTorque = speedTorque;
                    //carParticles.shiftParticle1.emissionRate = Mathf.Lerp(carParticles.shiftParticle1.emissionRate, 0, Time.deltaTime * 10.0f);
                    //carParticles.shiftParticle2.emissionRate = Mathf.Lerp(carParticles.shiftParticle2.emissionRate, 0, Time.deltaTime * 10.0f);
                }


                w.rotation = Mathf.Repeat(w.rotation + Time.deltaTime * col.rpm * 360.0f / 60.0f, 360.0f);
                w.rotation2 = Mathf.Lerp(w.rotation2, col.steerAngle, 0.1f);
                w.wheel.localRotation = Quaternion.Euler(w.rotation, w.rotation2, 0.0f);



                Vector3 lp = w.wheel.localPosition;


                if (col.GetGroundHit(out hit))
                {


                    if (brakeParticlePrefab)
                    {
                        if (Particle[currentWheel] == null)
                        {
                            Particle[currentWheel] = Instantiate(brakeParticlePrefab, w.wheel.position, Quaternion.identity) as GameObject;
                            Particle[currentWheel].name = "WheelParticle";
                            Particle[currentWheel].transform.parent = transform;
                            Particle[currentWheel].AddComponent<AudioSource>();
                            Particle[currentWheel].GetComponent<AudioSource>().maxDistance = 50;
                            Particle[currentWheel].GetComponent<AudioSource>().spatialBlend = 1;
                            Particle[currentWheel].GetComponent<AudioSource>().dopplerLevel = 5;
                            Particle[currentWheel].GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Custom;
                        }


                        var pc = Particle[currentWheel].GetComponent<ParticleSystem>();
                        bool WGrounded = false;



                        if (WGrounded && speed > 5 && !brake)
                        {



                            Particle[currentWheel].GetComponent<AudioSource>().volume = 0.5f;

                            if (!Particle[currentWheel].GetComponent<AudioSource>().isPlaying)
                                Particle[currentWheel].GetComponent<AudioSource>().Play();

                        }
                        else if ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && speed > 1)
                        {

                            if ((accel < 0.0f) || ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && (w == wheels[2] || w == wheels[3])))
                            {

                                if (!Particle[currentWheel].GetComponent<AudioSource>().isPlaying)
                                    Particle[currentWheel].GetComponent<AudioSource>().Play();

                                Particle[currentWheel].GetComponent<AudioSource>().volume = 10;

                            }

                        }
                        else
                        {

                            Particle[currentWheel].GetComponent<AudioSource>().volume = Mathf.Lerp(Particle[currentWheel].GetComponent<AudioSource>().volume, 0, Time.deltaTime * 10.0f);
                        }

                    }


                    lp.y -= Vector3.Dot(w.wheel.position - hit.point, transform.TransformDirection(0, 1, 0) / transform.lossyScale.x) - (col.radius);
                    lp.y = Mathf.Clamp(lp.y, -10.0f, w.pos_y);
                    floorContact = floorContact || (w.drive);


                }
                else
                {

                    if (Particle[currentWheel] != null)
                    {
                        var pc = Particle[currentWheel].GetComponent<ParticleSystem>();

                    }



                    lp.y = w.startPos.y - suspensionDistance;

                    rigidBody.AddForce(Vector3.down * 5000);

                }

                currentWheel++;
                w.wheel.localPosition = lp;


            }

            if (motorizedWheels > 1)
            {
                rpm = rpm / motorizedWheels;
            }


            motorRPM = 0.95f * motorRPM + 0.05f * Mathf.Abs(rpm * gears[currentGear]);
            if (motorRPM > 5500.0f) motorRPM = 5200.0f;


            int index = (int)(motorRPM / efficiencyTableStep);
            if (index >= efficiencyTable.Length) index = efficiencyTable.Length - 1;
            if (index < 0) index = 0;



            float newTorque = curTorque * gears[currentGear] * efficiencyTable[index];

            foreach (WheelComponent w in wheels)
            {
                WheelCollider col = w.collider;

                if (w.drive)
                {

                    if (Mathf.Abs(col.rpm) > Mathf.Abs(wantedRPM))
                    {

                        col.motorTorque = 0;
                    }
                    else
                    {
                        // 
                        float curTorqueCol = col.motorTorque;

                        if (!brake && accel != 0 && NeutralGear == false)
                        {
                            if ((speed < LimitForwardSpeed && currentGear > 0) ||
                                (speed < LimitBackwardSpeed && currentGear == 0))
                            {

                                col.motorTorque = curTorqueCol * 0.9f + newTorque * 1.0f;
                            }
                            else
                            {
                                col.motorTorque = 0;
                                col.brakeTorque = 2000;
                            }


                        }
                        else
                        {
                            col.motorTorque = 0;

                        }
                    }

                }





                if (brake || slip2 > 2.0f)
                {
                    col.steerAngle = Mathf.Lerp(col.steerAngle, steer * w.maxSteer, 0.02f);
                }
                else
                {

                    float SteerAngle = Mathf.Clamp(speed / maxSteerAngle, 1.0f, maxSteerAngle);
                    col.steerAngle = steer * (w.maxSteer / SteerAngle);


                }

            }

            // calculate pitch (keep it within reasonable bounds)
            Pitch = Mathf.Clamp(((motorRPM - idleRPM) / (shiftUpRPM - idleRPM)), 0.3f, 5.0f);

            shiftTime = Mathf.MoveTowards(shiftTime, 0.0f, 0.1f);

            if (Pitch == 1)
            {
                IdleEngine.volume = Mathf.Lerp(IdleEngine.volume, 1.0f, 0.1f);
                LowEngine.volume = Mathf.Lerp(LowEngine.volume, 0.5f, 0.1f);
                HighEngine.volume = Mathf.Lerp(HighEngine.volume, 0.0f, 0.1f);

            }
            else
            {

                IdleEngine.volume = Mathf.Lerp(IdleEngine.volume, 1.8f - Pitch, 0.1f);


                if ((Pitch > PitchDelay || accel > 0) && shiftTime == 0.0f)
                {
                    LowEngine.volume = Mathf.Lerp(LowEngine.volume, 0.0f, 0.2f);
                    HighEngine.volume = Mathf.Lerp(HighEngine.volume, 0.5f, 0.1f);
                }
                else
                {
                    LowEngine.volume = Mathf.Lerp(LowEngine.volume, 0.5f, 0.1f);
                    HighEngine.volume = Mathf.Lerp(HighEngine.volume, 0.0f, 0.2f);
                }


                HighEngine.pitch = Pitch / 2;
                LowEngine.pitch = Pitch / 2;

                PitchDelay = Pitch;
            }

        }
 

        private int PLValue = 0;

 

        public void CarAccelForward(float amount)
        {
            accelFwd = amount;
         
        }

        public void CarAccelBack(float amount)
        {
            accelBack = amount;
        }

        public void CarSteer(float amount)
        {
            steerAmount = amount;
        }

        public void CarHandBrake(bool HBrakeing)
        {
            brake = HBrakeing;
        }

        public void CarShift(bool Shifting)
        {
            shift = Shifting;
        }


    }
}
