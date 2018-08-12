package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.Toast;

import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PracticalFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PracticalFragment extends Fragment {

    Button btnEmergency;

    public PracticalFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment PracticalFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PracticalFragment newInstance() {
        PracticalFragment fragment = new PracticalFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_practical, container, false);
        btnEmergency = view.findViewById(R.id.emergencyButton);
        btnEmergency.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                callEmergency();
            }
        });
        return view;
    }

    private void callEmergency() {

            Intent intent = new Intent(Intent.ACTION_DIAL);
            intent.setData(Uri.parse("tel:+32474261401" ));
            startActivity(intent);

    }



}
